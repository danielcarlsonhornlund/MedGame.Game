using System;
using System.Collections.Generic;
using System.Text;

namespace MedGame.DTO.AzureADUser
{
    public class AzureADGet
    {
        public string objectType { get; set; }
        public string objectId { get; set; }
        public object deletionTimestamp { get; set; }
        public bool accountEnabled { get; set; }
        public object ageGroup { get; set; }
        public List<object> assignedLicenses { get; set; }
        public List<object> assignedPlans { get; set; }
        public string city { get; set; }
        public string companyName { get; set; }
        public string consentProvidedForMinor { get; set; }
        public string country { get; set; }
        public DateTime createdDateTime { get; set; }
        public string creationType { get; set; }
        public string department { get; set; }
        public string dirSyncEnabled { get; set; }
        public string displayName { get; set; }
        public string employeeId { get; set; }
        public string facsimileTelephoneNumber { get; set; }
        public string givenName { get; set; }
        public string immutableId { get; set; }
        public string isCompromised { get; set; }
        public string jobTitle { get; set; }
        public string lastDirSyncTime { get; set; }
        public string legalAgeGroupClassification { get; set; }
        public string mail { get; set; }
        public string mailNickname { get; set; }
        public string mobile { get; set; }
        public object onPremisesDistinguishedName { get; set; }
        public object onPremisesSecurityIdentifier { get; set; }
        public List<object> otherMails { get; set; }
        public string passwordPolicies { get; set; }
        public object passwordProfile { get; set; }
        public object physicalDeliveryOfficeName { get; set; }
        public object postalCode { get; set; }
        public object preferredLanguage { get; set; }
        public List<object> provisionedPlans { get; set; }
        public List<object> provisioningErrors { get; set; }
        public List<object> proxyAddresses { get; set; }
        public DateTime refreshTokensValidFromDateTime { get; set; }
        public object showInAddressList { get; set; }
        public List<object> signInNames { get; set; }
        public object sipProxyAddress { get; set; }
        public object state { get; set; }
        public object streetAddress { get; set; }
        public string surname { get; set; }
        public object telephoneNumber { get; set; }
        public object usageLocation { get; set; }
        public List<object> userIdentities { get; set; }
        public string userPrincipalName { get; set; }
        public object userState { get; set; }
        public object userStateChangedOn { get; set; }
        public string userType { get; set; }
    }
}
