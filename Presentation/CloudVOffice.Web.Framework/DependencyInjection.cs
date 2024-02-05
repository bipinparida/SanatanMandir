using CloudVOffice.Core.Domain.LocationMaster;
using CloudVOffice.Core.Infrastructure.Http;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Applications;

using CloudVOffice.Services.Authentication;
using CloudVOffice.Services.Company;
using CloudVOffice.Services.Comunication;
using CloudVOffice.Services.Customer;
using CloudVOffice.Services.Email;
using CloudVOffice.Services.EmailTemplates;
using CloudVOffice.Services.LoactionMaster;
using CloudVOffice.Services.Logging;
using CloudVOffice.Services.Pandit;
using CloudVOffice.Services.Permissions;

using CloudVOffice.Services.Roles;
using CloudVOffice.Services.SanatanMandir.PoojaCategories;
using CloudVOffice.Services.SanatanMandir.Temples;
using CloudVOffice.Services.SanatanUsers;
using CloudVOffice.Services.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CloudVOffice.Web.Framework
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(typeof(ISqlRepository<>), typeof(SqlRepository<>));
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserViewPermissions, UserViewPermissionService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IApplicationInstallationService, ApplicationInstallationService>();
            services.AddScoped<IHttpWebClients, HttpWebClients>();
            services.AddScoped<IEmailAccountService, EmailAccountService>();
            services.AddScoped<IEmailDomainService, EmailDomainService>();

            services.AddScoped<IEmailTemplateService, EmailTemplateService>();
            services.AddScoped<ICompanyDetailsService, CompanyDetailsService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILetterHeadService, LetterHeadService>();

            services.AddScoped<IErrorLogService, ErrorLogService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IPoojaCategoryService, PoojaCategoryService>();
            services.AddScoped<ITempleService, TempleService>();
            services.AddScoped<ISanatanUserService, SanatanUserService>();
            services.AddScoped<IPanditRegistrationService, PanditRegistrationService>();
            services.AddScoped<ICustomerRegistrationService, CustomerRegistrationService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            return services;

        }
    }
}