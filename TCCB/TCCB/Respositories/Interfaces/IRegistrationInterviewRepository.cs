using TCCB.Models.DAO;
using TCCB.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Interfaces
{
    public interface IRegistrationInterviewRepository
    {
        RegistrationInterview CreateRegistrationInterview( string candidateName, string identifyCard, int? ManagementUnitId, int? RegistrationPrice, int? CreatedBy);
        RegistrationInterview GetRegistrationInterviewById(int id);
        List<RegistrationInterview> GetRegistrationInterviewByIdentidfyCard(string identifyCard);
        RegistrationInterview UpdateRegistrationInterview(RegistrationInterviewDTO registrationInterviewDTO);
        RegistrationInterview GetRegistrationInterviewByIdAndIdentifyCard(int id, string identifyCard);
        RegistrationInterview UpdateRegistrationInterviewApprovedBy(RegistrationInterviewDTO registrationInterviewDTO);
        RegistrationInterview GetRegistrationInterviewByIdWithDetail(int id);
        List<RegistrationInterview> GetRegistrationInterviewByIdentidfyCardAndManagementUnitId(string identifyCard, int? managementUnitId);
        List<RegistrationInterview> GetAllRegistrationInterviewByManagementUnitId(int? id);
        List<RegistrationInterview> GetRegistrationInterviewsByManagementUnitIdCompleted(int? id);
        List<RegistrationInterview> GetRegistrationInterviewsByManagementUnitIdInProcess(int? id);
        List<RegistrationInterview> GetAllRegistrationInterviewByManagementUnitIdWithDetail(int? id);
        List<RegistrationInterview> GetAllRegistrationInterviewByManagementUnitIdValidRegistration(int? id);
    }
}