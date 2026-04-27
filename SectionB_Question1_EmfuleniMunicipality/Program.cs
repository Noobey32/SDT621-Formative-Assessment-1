using SectionB_Question1_EmfuleniMunicipality;
using System.Net.Security;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Emfuleni Municipality Service Desk ===");
        Console.WriteLine("*Application works best in full screen");

        Console.WriteLine("\n=== Resident Registration ===");
        Resident[] residents = RegisterResidents();

        UtilitiesManager utilitiesManager = new UtilitiesManager();

        Console.WriteLine("\n=== Service Request Logging ===");
        ServiceRequest[] serviceRequests = utilitiesManager.SetServiceRequests(residents);

        Console.WriteLine("\nCreating request summary...");
        Thread.Sleep(1000); // simulate generation time - UX

        Console.WriteLine("\n=== Service Requests Summary ===");
        utilitiesManager.DisplayServiceRequests(serviceRequests, true);

        Thread.Sleep(1000); // UX
        Console.WriteLine("=== Service Request Processing ===");
        ServiceRequest[] processedRequests = ProcessServiceRequests(serviceRequests);

        Console.WriteLine("\nGenerating report...");
        Thread.Sleep(500); // simulate generation time
        Console.WriteLine("\n=== == === === ==== === === == ===");

        Thread.Sleep(1500);
        Console.WriteLine("\n=== Processed Service Requests ===");
        utilitiesManager.DisplayServiceRequests(processedRequests, false);

        Thread.Sleep(1500);
        Console.WriteLine("=== Final Municipal Report ===");
        FinalizedReport(residents, serviceRequests, processedRequests);
        Console.WriteLine("\n=== == === === ==== === === == ===");

        Thread.Sleep(2000);
        Console.WriteLine("\nThank you for using the Emfuleni Municipality Service Desk. Goodbye!");
    }

    // Capture residents dynamically
    private static Resident[] RegisterResidents()
    {
        Helpers helpers = new();

        int numberOfResidentsToRegister = helpers.GetValidInt("How many residents would you like to register? ");
        Resident[] residents = new Resident[numberOfResidentsToRegister];

        for (int i = 0; i < numberOfResidentsToRegister; i++)
        {
            Console.WriteLine($"\n--- Resident {i + 1} ---");

            string fullName = helpers.GetStringValue("Full Name: "),
                address = helpers.GetStringValue("Address: "),
                accountNumber = helpers.GetStringValue("Account Number: ");
            int monthlyUtilityUsage = helpers.GetValidInt("Monthly Utility Usage (kWh): ");

            residents[i] = new Resident(fullName, address, accountNumber, monthlyUtilityUsage);
        }
        return residents;
    }

    private static ServiceRequest[] ProcessServiceRequests(ServiceRequest[] serviceRequests)
    {
        Helpers helpers = new();
        List<ServiceRequest> pendingRequests = new List<ServiceRequest>();

        Console.WriteLine($"Using the summary above, enter which requests you would like to process. (1 to {serviceRequests.Length}; 0 = stop)");

        while (true)
        {
            int requestToProcess = helpers.GetValidInt($"Process request #", 0, serviceRequests.Length); // 0 is used to stop the loop

            // if 0 is entered, or all requests have been processed, stop the loop and return the pending requests
            if (requestToProcess == 0)
                return pendingRequests.ToArray();

            // avoid duplicates
            if (pendingRequests.Contains(serviceRequests[requestToProcess - 1]))
            {
                Console.WriteLine("This request has already been processed. Please select a different request.");
                continue;
            }
            else
                pendingRequests.Add(serviceRequests[requestToProcess - 1]);

            // exit early
            if (pendingRequests.Count == serviceRequests.Length)
            {
                Console.WriteLine("All requests have been selected for processing.");
                return pendingRequests.ToArray();
            }
        }
        
    }

    private static void OutputHighestUrgencyRequest(ServiceRequest[] processedRequests)
    {
        if (processedRequests.Length == 0)
        {
            return;
        }

        // sort
        ServiceRequest highestUrgencyRequest = processedRequests[0];
        foreach (ServiceRequest request in processedRequests)
        {
            if (request.UrgencyScore > highestUrgencyRequest.UrgencyScore)
                highestUrgencyRequest = request;
        }

        Console.WriteLine("\n--- Highest Urgency Request ---");
        Console.WriteLine($"Resident: {highestUrgencyRequest.Resident.FullName}\n" +
            $"Service Type: {highestUrgencyRequest.RequestType}\n" +
            $"Urgency Score: {highestUrgencyRequest.UrgencyScore}\n" +
            $"Estimated Resolution Time: {highestUrgencyRequest.EstimatedResolutionTime} hours\n" +
            $"Household Impact Score: {highestUrgencyRequest.ImpactScore}");
    }

    // List totals and highest urgency of all processed requests
    private static void FinalizedReport(Resident[] residents, ServiceRequest[] serviceRequests, ServiceRequest[] processedRequests)
    {
        Console.WriteLine($"Total Residents Registered: {residents.Length}");
        Console.WriteLine($"Total Requests Logged: {serviceRequests.Length}");
        Console.WriteLine($"Total Requests Processed: {processedRequests.Length}");
        OutputHighestUrgencyRequest(processedRequests);
    }
}