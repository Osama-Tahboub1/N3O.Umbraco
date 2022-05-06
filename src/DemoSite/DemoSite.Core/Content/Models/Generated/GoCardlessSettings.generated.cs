//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v9.5.0+1c39c27e220efde6f0f360b94b6e7b6a1f0f0e59
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace DemoSite.Core.Content
{
	/// <summary>GoCardless Settings</summary>
	[PublishedModel("goCardlessSettings")]
	public partial class GoCardlessSettings : PublishedContentModel, IPaymentMethodSettings
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.5.0+1c39c27e220efde6f0f360b94b6e7b6a1f0f0e59")]
		public new const string ModelTypeAlias = "goCardlessSettings";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.5.0+1c39c27e220efde6f0f360b94b6e7b6a1f0f0e59")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.5.0+1c39c27e220efde6f0f360b94b6e7b6a1f0f0e59")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.5.0+1c39c27e220efde6f0f360b94b6e7b6a1f0f0e59")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<GoCardlessSettings, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public GoCardlessSettings(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Access Token
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.5.0+1c39c27e220efde6f0f360b94b6e7b6a1f0f0e59")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("productionAccessToken")]
		public virtual string ProductionAccessToken => this.Value<string>(_publishedValueFallback, "productionAccessToken");

		///<summary>
		/// Access Token
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.5.0+1c39c27e220efde6f0f360b94b6e7b6a1f0f0e59")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("stagingAccessToken")]
		public virtual string StagingAccessToken => this.Value<string>(_publishedValueFallback, "stagingAccessToken");

		///<summary>
		/// Restrict Collection Days To
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.5.0+1c39c27e220efde6f0f360b94b6e7b6a1f0f0e59")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("restrictCollectionDaysTo")]
		public virtual global::System.Collections.Generic.List<global::N3O.Umbraco.Lookups.DayOfMonth> RestrictCollectionDaysTo => global::DemoSite.Core.Content.PaymentMethodSettings.GetRestrictCollectionDaysTo(this, _publishedValueFallback);

		///<summary>
		/// Transaction Description
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.5.0+1c39c27e220efde6f0f360b94b6e7b6a1f0f0e59")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("transactionDescription")]
		public virtual string TransactionDescription => global::DemoSite.Core.Content.PaymentMethodSettings.GetTransactionDescription(this, _publishedValueFallback);

		///<summary>
		/// Transaction ID
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.5.0+1c39c27e220efde6f0f360b94b6e7b6a1f0f0e59")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("transactionId")]
		public virtual string TransactionId => global::DemoSite.Core.Content.PaymentMethodSettings.GetTransactionId(this, _publishedValueFallback);
	}
}
