namespace Identity.API.Models.ConsentViewModels
{
    public record ScopeViewModel
    {

        public string Value { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Emphasize { get; set; }
        public bool Required { get; set; }
        public bool Checked { get; set; }
    }

    //public record ScopeViewModel
    //{
    //    public ScopeViewModel(ApiResource scope, bool check)
    //    {
    //        Name = scope.Name;
    //        DisplayName = scope.DisplayName;
    //        Description = scope.Description;
    //        //Emphasize = scope.Emphasize;
    //        //Required = scope.Required;
    //        //Checked = check || scope.Required;
    //    }

    //    public ScopeViewModel(IdentityResource identity, bool check)
    //    {
    //        Name = identity.Name;
    //        DisplayName = identity.DisplayName;
    //        Description = identity.Description;
    //        Emphasize = identity.Emphasize;
    //        Required = identity.Required;
    //        Checked = check || identity.Required;
    //    }

    //    public string Name { get; init; }
    //    public string DisplayName { get; init; }
    //    public string Description { get; init; }
    //    public bool Emphasize { get; init; }
    //    public bool Required { get; init; }
    //    public bool Checked { get; init; }
    //}
}
