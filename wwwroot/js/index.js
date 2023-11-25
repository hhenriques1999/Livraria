function ordenarPorVenda(a, b) {
    return b.vendas - a.vendas;
}
function ordenarPorNota(a, b) {
    return b.nota - a.nota;
}


if (book !== undefined) {
    console.log("Ordenando livros");
    book.sort(ordenarPorNota);
} else {
    console.error("Não temos livros");
}

function listarBookVendas(id, array) {
    let span = document.getElementById(id);
    span.innerHTML = '';

    for (let i = 0; i < 4; i++) {
        span.innerHTML += '<div class="book-container"><img src="' + array[i].imagem + '"><div style="padding: 15px;"><h5>' + array[i].nome + '</h5><p>' + array[i].autor + '</p><br><div style="position: absolute; top: 80%;"><p> R$ ' + array[i].preco + '</p><button class="btn btn-primary" onclick="getData(' + array[i].id + ')" >Ver Item</button></div></div>'
    }
}
listarBookVendas('mais-vendidos', book);

if (book !== undefined) {
    console.log("Ordenando livros");
    book.sort(ordenarPorNota);
} else {
    console.error("Não temos livros");
}

listarBookVendas('mais-avaliados', book);

function getData(i) {
    localStorage.setItem("value", i);
    window.location.href = "produto.html";
}