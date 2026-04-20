using SectionB_Question1_EmfuleniMunicipality;
using System.Net.Security;
using System.Runtime.CompilerServices;

class Program
{
    private static Helpers helpers = new();

    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Emfuleni Municipality Service Desk ===\n");
        int numberOfResidents = helpers.GetValidInt("How many residents would you like to register? ");

        Console.WriteLine("\n=== Resident Registration ===");
        Resident[] residents = RegisterResidents();

        UtilitiesManager utilitiesManager = new UtilitiesManager();

        Console.WriteLine("\n=== Service Request Logging ===");
        ServiceRequest[] serviceRequests = utilitiesManager.SetServiceRequests(residents);

        Console.WriteLine("\n=== Service Requests Summary ===");
        utilitiesManager.DisplayServiceRequests(serviceRequests, true);

        Console.WriteLine("\n=== Service Request Processing ===");
        ServiceRequest[] processedRequests = ProcessServiceRequests(serviceRequests);

        Console.WriteLine("\n=== Processed Service Requests ===");
        utilitiesManager.DisplayServiceRequests(processedRequests, false);

        Console.WriteLine("\n=== Final Municipal Report ===");
        Console.WriteLine($"Total Residents Registered: {residents.Length}");
        Console.WriteLine($"Total Service Requests Logged: {serviceRequests.Length}");
        Console.WriteLine($"Total Service Requests Processed: {processedRequests.Length}");
        // todo output request with the highest urgency score

        Console.WriteLine("\nThank you for using the Emfuleni Municipality Service Desk. Goodbye!");
    }

    private static Resident[] RegisterResidents()
    {
        int numberOfResidentsToRegister = helpers.GetValidInt("How many residents would you like to register? ");
        Resident[] residents = new Resident[numberOfResidentsToRegister];

        for (int i = 0; i < numberOfResidentsToRegister; i++)
        {
            Console.WriteLine($"\n--- Regisident {i + 1} ---");

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
        List<ServiceRequest> pendingRequests = [];

        while (true)
        {
            int requestToProcess = helpers.GetValidInt($"Which request would you like to process? (1 to {serviceRequests.Length}; 0 = stop): ", 0, serviceRequests.Length);

            if (requestToProcess == 0) return [.. pendingRequests];

            if (pendingRequests.Contains(serviceRequests[requestToProcess - 1]))
                Console.WriteLine("This request has already been processed. Please select a different request.");
            else 
                pendingRequests.Add(serviceRequests[requestToProcess - 1]);
        }
        
    }
}