function CommonSuccess(data) { 
    var productionMode = $('#ProductionMode');       
    productionMode.val(data.ProductionMode);

    var wcfUrl = $('#WcfUrl');
    wcfUrl.val(data.WcfUrl);

    var wcfUserName = $('#WcfUserName');
    wcfUserName.val(data.WcfUserName);

    var wcfPassword = $('#WcfPassword');
    wcfPassword.val(data.WcfPassword);

    var companyName = $('#CompanyName');
    companyName.val(data.CompanyName);

    var buildingName = $('#BuildingName');
    buildingName.val(data.BuildingName);


    var streetName = $('#StreetName');
    streetName.val(data.StreetName);

    var city = $('#City');
    city.val(data.City);

    var postalCode = $('#PostalCode');
    postalCode.val(data.PostalCode);
}

function RecycleSuccess() {
    var success = $('#success');
    success.show();
}

function ConfigurationSuccess(data) {
    var maintenanceMode = $('#MaintenanceMode');
    maintenanceMode.val(data.MaintenanceMode);
}
