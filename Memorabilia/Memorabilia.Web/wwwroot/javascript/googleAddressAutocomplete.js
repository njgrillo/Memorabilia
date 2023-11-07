let autocompleteMultiLine;
let autocompleteSingleLine;

function fillInMultiLineAddress() {
    const place = autocompleteMultiLine.getPlace();
    var address1 = "";
    var city = "";
    var country = "";
    var state = "";
    var postcode = "";

    for (const component of place.address_components) {
        const componentType = component.types[0];

        switch (componentType) {
            case "street_number": {
                address1 = `${component.long_name} ${address1}`;
                break;
            }
            case "route": {
                address1 += component.short_name;
                break;
            }
            case "postal_code": {
                postCode = `${component.long_name}`;
                break;
            }
            case "postal_code_suffix": {
                postCode = `${postCode}-${component.long_name}`;
                break;
            }
            case "locality":
                city = component.long_name;
                break;
            case "administrative_area_level_1": {
                state = component.short_name;
                break;
            }
            case "country":
                country = component.long_name;
                break;
        }
    }

    var address1Field = document.querySelector("#address1");
    address1Field.value = address1;

    var cityField = document.querySelector("#locality");
    cityField.value = city;

    var stateField = document.querySelector("#state");
    stateField.value = state;

    var countryField = document.querySelector("#country");
    countryField.value = country;

    var postalField = document.querySelector("#postCode");
    postalField.value = postCode;

    var event = new Event('change');

    address1Field.dispatchEvent(event);
    cityField.dispatchEvent(event);
    stateField.dispatchEvent(event);
    countryField.dispatchEvent(event);
    postalField.dispatchEvent(event);
}

function fillInSingleLineAddress() {
    const place = autocompleteSingleLine.getPlace();
    var address = "";
    var city = "";
    var stateProvidence = "";
    var postalCode = "";
    var country = "";

    for (const component of place.address_components) {
        const componentType = component.types[0];

        switch (componentType) {
            case "street_number": {
                address = `${component.long_name} ${address}`;
                break;
            }
            case "route": {
                address += component.short_name;
                break;
            }
            case "postal_code": {
                postalCode = `${component.long_name}`;
                break;
            }
            case "postal_code_suffix": {
                postalCode = `${postalCode}-${component.long_name}`;
                break;
            }
            case "locality":
                city = component.long_name;
                break;
            case "administrative_area_level_1": {
                stateProvidence = component.short_name;
                break;
            }
            case "country":
                country = component.long_name;
                break;
        }
    }

    var addressField = document.querySelector("#address");
    addressField.value = `${address} ${city} ${stateProvidence} ${postalCode} ${country}`;

    var event = new Event('change');

    addressField.dispatchEvent(event);
}

function initializeMultiLineAddressAutocomplete() {
    var address1Field = document.querySelector("#address1");

    autocompleteMultiLine = new google.maps.places.Autocomplete(address1Field, {
        componentRestrictions: { country: ["us", "ca"] },
        fields: ["address_components", "geometry"],
        types: ["address"],
    });

    address1Field.focus();

    autocompleteMultiLine.addListener("place_changed", fillInMultiLineAddress);
}

function initializeSingleLineAddressAutocomplete() {
    var addressField = document.querySelector("#address");

    autocompleteSingleLine = new google.maps.places.Autocomplete(addressField, {
        componentRestrictions: { country: ["us", "ca"] },
        fields: ["address_components", "geometry"],
        types: ["address"],
    });

    autocompleteSingleLine.addListener("place_changed", fillInSingleLineAddress);
}