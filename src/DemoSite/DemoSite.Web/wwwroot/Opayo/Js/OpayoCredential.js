// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let msk;
let timeOutForThreeDSecureFrame;
let transactionID;
GetMerchantSessionKeyAsync()
    .then((merchantSessionKey) => {
        let sp = sagepayCheckout({merchantSessionKey: merchantSessionKey, onTokenise: onIdentifierReceived});
        sp.form();
    });

async function GetMerchantSessionKeyAsync() {
    return fetch('umbraco/api/Opayo/merchantSessionKey')
        .then((response) => response.json())
        .then((response) => {
            msk = response.key;
            return msk;
        }).catch(e => console.log(e));
}
function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
        let r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}
async function ProcessPayment(cardIdentifier, merchantSessionKey) {
    let guid =  uuidv4();
    const link = "umbraco/api/Opayo/"+guid+"/credential/create";
    console.log(link);
    await fetch(link, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            advancePayment : {
                cardIdentifier: cardIdentifier,
                merchantSessionKey: merchantSessionKey,
                challengeWindowSize : "large",
                browserParameters: {
                    screenWidth: 512,
                    screenHeight: 512,
                    colorDepth: 12,
                    javaEnabled: false,
                    javaScriptEnabled: true,
                    timezone: "utc",
                },
                Value: {
                    amount: 12,
                    currency: "gbp",
                },
                saveCard: true,
                callbackUrl : "https://127.0.0.1:5001/umbraco/api/Credential/credential" 
            }
        }),
    }).then((response) => {
        let res = response.json();
        return res;
    })
        .then((response) => {
            if (response.errors) return Promise.reject(response);
            else {
                console.log(response);
                transactionID = response.transactionId;
                if (response.result.advancePayment.requireThreeDSecure ) {
                    Activate3DsForm(transactionID, response.result.advancePayment);
                } else {
                    ShowSuccessMessage();

                    $("#threeDSecureModal").hide();
                }
                return response;
            }
        }).catch(e => {
            console.log(e)
        });
}

function Activate3DsForm(transactionID, payment) {
    $("#threeDSecureModal").modal();
    let form = document.getElementById("3dSecureIframeForm");
    form.action = payment.threeDSecureUrl;
    form[0].value = payment.cReq
    form[1].value = payment.transactionId; 
    form[2].value = payment.acsTransId; 
    form.hidden = false

    form.submit();
}

async function FetchThreeDSecureStatus() {
    let form = document.getElementById("3dSecureIframeForm");
    let transactionId = form[1].value;
    console.info("Getting the status of transaction" + transactionId);
    await fetch("umbraco/api/Opayo/3DSecureStatus/" + transactionId, {
        method: "GET"
    }).then(response => {
        if (response.status == 200) {
            let res = response.json();
            return res;
        }
    }).then((response) => {
        if (response == null) {
            return;
        }
        if (response.errors) return Promise.reject(response);
        else {
            console.log(response);
            if (response.completed && response.success) {
                $("#threeDSecureModal").hide();
                ShowSuccessMessage();
                clearTimeout(timeOutForThreeDSecureFrame);
            } else if(response.completed && !response.success){
                ShowFailureMessage(response.details);
            }
            return response;
        }
    }).catch(e => console.log(e));
}

function onIdentifierReceived(data) {
    if (data.success) {
        ProcessPayment(data.cardIdentifier, msk);
    } else if (data.error !== null) {
        ShowFailureMessage(data.error.errorMessage);
    }
}

function ShowFailureMessage(details) {
    let area = document.getElementById("failureMessage");
    area.innerHTML = "<p> Your Payment has failed. The details of failure are : " + details + "</p>";

    $("#failureModal").modal();
}

function ShowSuccessMessage() {
    let area = document.getElementById("successMessage");
    area.innerHTML = "<p> Your Payment has been made sucessfully. Please note down the transaction ID '" + transactionID + "' </p>";
    $("#successModal").modal();
}
