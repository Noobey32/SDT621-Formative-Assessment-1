using System;
using System.Collections.Generic;
using System.Text;

namespace SectionB_Question1_EmfuleniMunicipality
{
    internal class UtilitiesManager
    {
        public int GetUrgencyScore(ServiceRequest request)
        {
            // 1. Priority is doubled to bring it to the same level as severity.
            // 2. Both are multiplied by 4 to scale from 1 to 80
            // 3. Estimated resolution time is added to give a final urgency score.
            int urgencyScore = ((request.PriorityLevel * 2) * 4) + (request.ServerityLevel * 4) + request.EstimatedResolutionTime;

            // Limit the urgency score to a maximum of 100 to prevent excessively high scores.
            return urgencyScore < 100 ? urgencyScore : 100;
        }

        public long GetImpactScore(ServiceRequest request)
        {
            return request.Resident.MonthlyUtilityUsage * (request.ServerityLevel / 10);
        }

        public void DisplayServiceRequests(ServiceRequest[] serviceRequests, bool includeNumbering)
        {
            for (int i = 0; i < serviceRequests.Length; i++)
            {
                if (includeNumbering)
                    Console.Write($"{i + 1}. "); // numbering is used for processing requests after logging

                Console.WriteLine($"Resident: {serviceRequests[i].Resident.FullName}\n" +
                    $"Service Type: {serviceRequests[i].RequestType}\n" +
                    $"Urgency Score: {serviceRequests[i].UrgencyScore}\n" +
                    $"Estimated Resolution Time: {serviceRequests[i].EstimatedResolutionTime} hours\n" +
                    $"Household Impact Score: {serviceRequests[i].ImpactScore}\n");
            }
        }

        // Function: User can log service requests interactively > object is then created via ServiceRequest.cs
        public ServiceRequest[] SetServiceRequests(Resident[] residents)
        {
            Helpers helpers = new();

            int numberOfServiceRequests = helpers.GetValidInt("How many service requests would you like to log? ");
            ServiceRequest[] serviceRequests = new ServiceRequest[numberOfServiceRequests];

            for (int i = 0; i < numberOfServiceRequests; i++)
            {
                Console.WriteLine($"\n--- Service Request {i + 1} ---");

                int residentAssigned = helpers.GetValidInt($"Which resident is this request for? (1 to {residents.Length}): ", 1, residents.Length);
                string requestType = helpers.GetStringValue("Request Type: ");
                int priorityLevel = helpers.GetValidInt("Priority Level (1-5): ", 1, 5),
                    severityLevel = helpers.GetValidInt("Severity Level (1-10): ", 1, 10),
                    estimatedResolutionTime = helpers.GetValidInt("Estimated Resolution Time (hours): ");

                serviceRequests[i] = new ServiceRequest(residents[residentAssigned - 1], requestType, priorityLevel, severityLevel, estimatedResolutionTime); // urgency score is added within ServiceRequest.cs
            }
            return serviceRequests;
        }
    }
}
