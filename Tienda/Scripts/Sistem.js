$(document).ready(function () {
    $('#FECHA_FACTURA').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
        language: 'es'
    });

    $('#fechaInicio').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
        language: 'es'
    });

    $('#fechaFin').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
        language: 'es'
    });
});
function AgregarProducto() {
    var idProducto = $('#codigoProducto').val();
    var cantidadProductos = $('#bodyTableDetalle tr').length;
    console.log(cantidadProductos);
    $.ajax({
        type: "POST",
        url: "/facturas/BuscarProducto?idProducto=" + idProducto + "&cantidadProductos=" + cantidadProductos,
        success: function (response) {
            $('#bodyTableDetalle').append(response);
            $('#codigoProducto').val('');
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}
function CalcularTotalProducto(element, indice, event) {
    var value = $(element).val();
    var costoTotal = value * $('#PrecioUnitario' + indice).val().replace(",", ".");
    $('#factura_producto_' + indice + '__PRECIO_TOTAL_PRODUCTO').val(String(costoTotal).replace('.', ','));
    CalcularTotal();
}
function SoloNumeros(event) {
    if ($.inArray(event.key, ["1", "2", "3", "4", "5", "6", "7", "8", "9", "0"]) === -1) {
        event.preventDefault();
    }
}
function CalcularTotal() {
    var cantidadProductos = $('#bodyTableDetalle tr').length;
    var total = 0;
    for (var indice = 0; indice < cantidadProductos; indice++) {
        var valorProd = $('#factura_producto_' + indice + '__PRECIO_TOTAL_PRODUCTO').val();
        var valorTotal = $('#factura_producto_' + indice + '__PRECIO_TOTAL_PRODUCTO').val()? $('#factura_producto_' + indice + '__PRECIO_TOTAL_PRODUCTO').val():'0';
        total = total + Number(valorTotal.replace(",", "."));
    }
    $('#PRECIO_TOTAL').val(String(total).replace('.', ','));
}

function BuscarProducto() {
    var idProducto = $('#codigoProducto').val();
    $.ajax({
        type: "POST",
        url: "/productoes/BuscarProducto?idProducto=" + idProducto,
        success: function (response) {
            $('#tableProductos').html(response);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function BuscarVenta() {
    var fechaInicial = $('#fechaInicio').val();
    var fechaFinal = $('#fechaFin').val();
    $.ajax({
        type: "POST",
        url: "/facturas/BuscarVentas?fechaInicial=" + $('#fechaInicio').val() + "&fechaFinal=" + $('#fechaFin').val(),
        async: false,
        success: function (response) {
            $('#tableVentas').html(response);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function DeleteRow(element, idElement) {
    $('#factura_producto_' + idElement + '__Estado').val('EL');
    $('#factura_producto_' + idElement + '__PRECIO_TOTAL_PRODUCTO').val('0');
    $(element).parent().parent().hide();
    CalcularTotal();
}