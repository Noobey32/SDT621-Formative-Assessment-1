using System;
using System.Collections.Generic;
using System.Text;

namespace SectionB_Question1_EmfuleniMunicipality
{
    internal class ServiceRequest
    {
        private Resident resident;
        private double impactScore;
        private string requestType;
        private int priorityLevel,
            serverityLevel,
            estimatedResolutionTime,
            urgencyScore;

        public ServiceRequest(Resident resident, string requestType, int priorityLevel, int serverityLevel, int estimatedResolutionTime)
        {
            this.resident = resident;
            this.requestType = requestType;
            this.priorityLevel = priorityLevel;
            this.serverityLevel = serverityLevel;
            this.estimatedResolutionTime = estimatedResolutionTime;

            UtilitiesManager utilitiesManager = new();
            this.urgencyScore = utilitiesManager.GetUrgencyScore(this); // requires variables that are already set
            this.impactScore = utilitiesManager.GetImpactScore(this);
        }

        public Resident Resident { get { return resident; } }
        public string RequestType { get { return requestType; } }
        public int PriorityLevel { get { return priorityLevel; } }
        public int ServerityLevel { get { return serverityLevel; } }
        public int EstimatedResolutionTime { get { return estimatedResolutionTime; } }
        public int UrgencyScore { get { return urgencyScore; } }
        public double ImpactScore { get {return impactScore; } }
    }
}
