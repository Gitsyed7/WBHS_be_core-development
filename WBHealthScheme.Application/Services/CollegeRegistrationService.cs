using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;

namespace WBHealthScheme.Application.Services
{

public class CollegeRegistrationService : ICollegeRegistrationService
{

private readonly ICollegeRegistrationRepository _repository;


public CollegeRegistrationService
(
      ICollegeRegistrationRepository repository
)
{
      _repository=repository;
}


public async Task<CheckHRMSResponse>
CheckHRMSAsync
(
      CheckHRMSRequest request
)
{

      throw new NotImplementedException();

}


}

}