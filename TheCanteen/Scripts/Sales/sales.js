//<reference path="../jQuery.js" />

function AddTransaction(productSelector, quantityTextbox, targetTable) {
	var productId = productSelector.val();
	var productName = productSelector.text();

	var quantity = quantityTextbox.val();

	var products = [{ productId: productId, productName: productName, quantity: quantity }];

	$("#productTemplate").tmpl(products).appendTo("#productTable");

	$("#productsJson").val(JSON.stringify($.merge($.parseJSON($("#productsJson").val()), products)));
}