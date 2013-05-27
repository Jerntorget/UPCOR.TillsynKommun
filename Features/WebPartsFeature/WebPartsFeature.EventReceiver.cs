using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace UPCOR.TillsynKommun.Features.WebPartsFeature
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("eb6b10c7-da6a-4043-866e-9cd1f9c3b9aa")]
    public class WebPartsFeatureEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties) {
            //SPSite site = properties.Feature.Parent as SPSite;

            //if (site != null) {
            //    SPWebApplication webApp = site.WebApplication;

            //    // Create a modification
            //    SPWebConfigModification mod = new SPWebConfigModification(
            //        "SafeControl[@Assembly=\"UPCOR.TillsynKommun, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f66bbd75f013e009\"][@Namespace=\"My.Namespace\"]"
            //            + "[@TypeName=\"*\"][@Safe=\"True\"][@AllowRemoteDesigner=\"True\"]"
            //        , "/configuration/SharePoint/SafeControls"
            //        );

            //    // Add the modification to the collection of modifications
            //    webApp.WebConfigModifications.Add(mod);

            //    // Apply the modification
            //    webApp.Farm.Services.GetValue<SPWebService>().ApplyWebConfigModifications();
            //}

        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
