namespace ReactRouteBackbone
{
    public class Program
    {
        static void Main(string[] args)
        {
            var reportsHub = new Hub(
                "reports",
                "dashboard, sales, operations, documentTransmissions"
            );

            var companyManageHub = new Hub(
                "manage", 
                "activities, documents, details, settings, delegations, integrations, restDocs, account, users, contacts"
                );

            var companiesHub = new Hub(
                "companies", 
                "index, activities, externalRegistry, connectorUpdates, automatches, agreementCustomers",
                companyManageHub
                );

            var documentsHub = new Hub(
                "documents",
                "overview, recentDocuments, transmission, view, uddiLookup, blacklistedUrls"
                );

            var marketingHub = new Hub(
                "marketing",
                "trialCampaigns, rollingNews, emailMarketingList, newsletter"
                );

            var root = new Hub(
                "adminApp", 
                "finance, users",
                reportsHub, companiesHub, documentsHub, marketingHub
                );

            root.Build(@"C:/Work/Repo/sproomAdminReact/sproom-admin-react/src");
        }
    }
}
