function VenderVeiculo(sUrl, data) {
    let url = 'https://' + sUrl + '/Veiculo/Vender/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            location.reload();
        }
    });
}

function IndisponibilizarVeiculo(sUrl, data) {
    let url = 'https://' + sUrl + '/Veiculo/Indisponibilizar/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            location.reload();
        }
    });
}