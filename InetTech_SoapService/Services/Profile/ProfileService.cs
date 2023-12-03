﻿using InetTech_SoapService.Entities;
using InetTech_SoapService.Faults;
using System.ServiceModel;

namespace InetTech_SoapService.Services;

public class ProfileService : IProfileService
{
    private List<Profile> _profiles = new List<Profile>()
        {
            new Profile() { FirstName = "Foo", LastName = "Profile1", Email = "fooprofiile1@yahoo.com", HomeAddress = "1 King Street West, Toronto, ON", ProfileID = 1 },
            new Profile() { FirstName = "Bar", LastName = "Profile2", Email = "barprofiile2@gmail.com", HomeAddress = "1 Hollywood Avenue, Los Angeles, CA", ProfileID = 2 },
        };

    public Profile GetProfile(int profileID)
    {
        var profile = _profiles.FirstOrDefault(p => p.ProfileID == profileID);
        if (profile == null)
        {
            throw new FaultException<TopicsEmptyFault>(new TopicsEmptyFault($"A profile with ID {profileID} is missing."),
                new FaultReason($"A profile with ID {profileID} is missing."),
                new FaultCode("MissingProfile"), null);
        }
        return profile;
    }
}