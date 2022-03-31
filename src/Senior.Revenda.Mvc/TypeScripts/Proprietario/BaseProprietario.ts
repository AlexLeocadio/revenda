function onChangeCep() {
    GetCep($('#Endereco_Cep').val());
}

function GetCep(cep) {
    let url = 'https://' + $("#url").val() + '/Proprietario/GetByCep?cep=' + cep;
    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            $('#Endereco_Cidade').val(data.City);
            $('#Endereco_Bairro').val(data.Neighborhood);
            $('#Endereco_Logradouro').val(data.Street);
        }
    });
}