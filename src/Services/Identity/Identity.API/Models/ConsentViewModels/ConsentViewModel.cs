namespace Identity.API.Models.ConsentViewModels
{
    public record ConsentViewModel : ConsentInputModel
    {
        public ConsentViewModel()
        {

        }

        //public ConsentViewModel(ConsentInputModel model, string returnUrl, AuthorizationRequest request, Client client, Resources resources)
        //{
        //    RememberConsent = model?.RememberConsent ?? true;
        //    ScopesConsented = model?.ScopesConsented ?? Enumerable.Empty<string>();

        //    ReturnUrl = returnUrl;

        //    ClientName = client.ClientName;
        //    ClientUrl = client.ClientUri;
        //    ClientLogoUrl = client.LogoUri;
        //    AllowRememberConsent = client.AllowRememberConsent;

        //    IdentityScopes = resources.IdentityResources.Select(x => new ScopeViewModel(x, ScopesConsented.Contains(x.Name) || model == null)).ToArray();
        //    //ResourceScopes = resources.ApiResources.Select(x => new ScopeViewModel(x, ScopesConsented.Contains(x.Name) || model == null)).ToArray();
        //}

        public string ClientName { get; set; }
        public string ClientUrl { get; set; }
        public string ClientLogoUrl { get; set; }
        public bool AllowRememberConsent { get; set; }

        public IEnumerable<ScopeViewModel> IdentityScopes { get; set; }
        public IEnumerable<ScopeViewModel> ApiScopes { get; set; }
    }

   
}
