using System.Collections.Generic; 

namespace Evite.Models
{
    public class AllResponses
    {
        private static List<ResponseToEvite> responses = new List<ResponseToEvite>();
    
        public static IEnumerable<ResponseToEvite> Responses {
            get {
                return responses;
            }
        }

        public static void AddResponse(ResponseToEvite responseToEvite) {
            responses.Add(responseToEvite);
        } 
    }
}