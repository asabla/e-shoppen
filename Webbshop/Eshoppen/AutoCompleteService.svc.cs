using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Eshoppen.Eshop;

namespace Eshoppen
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AutoCompleteService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public string[] CompleteText(string prefixText, int count)
        {
            I_EshopserviceClient client = new I_EshopserviceClient();
            DataTable result = new DataTable();
            try
            {
                result = client.GetProductsBySearch(prefixText);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong with autocomplete: " + ex.Message);
            }

            var rowColl = result.AsEnumerable();    //Makes it possible to use linq on datatable
            //Selects only all results under the column PTitle to a string array
            string[] products = (from r in rowColl select r.Field<string>("PTitle")).ToArray();

            return products;
        }
    }
}
