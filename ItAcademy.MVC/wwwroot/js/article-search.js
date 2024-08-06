document.addEventListener('DOMContentLoaded', function (event) {
    findImages();

    let searchBar = document.getElementById('article-search-autocomplete');
    searchBar.addEventListener('keyup', function (event) {
        if (searchBar.value.length >= 3) {
            searchArticle(searchBar.value);
        }
        else {
            clearVariants();
        }
    });
});

async function searchArticle(title) {
    let articleSearchData = document.getElementById('article-search');
    const myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    const request = new Request('https://localhost:7055/article/getarticletitles', {
        method: "POST",
        body: JSON.stringify({ title: title }),
        headers: myHeaders
    });
    const response = await fetch(request);

    
    if (!response.ok) {
                throw new Error(`Response status: ${response.status}`);
    }
    const json = await response.json();

    for (let value of json) {
        let dataopt = createDataElement(value);
        articleSearchData.appendChild(dataopt);
    }

}
//async function getData() {
//    try {
//        const response = await fetch(url);
//        if (!response.ok) {
//            throw new Error(`Response status: ${response.status}`);
//        }

//        const json = await response.json();
//        console.log(json);
//    } catch (error) {
//        console.error(error.message);
//    }
//}

function createDataElement(value) {
    const opt = document.createElement("option");
    opt.value = value;
    return opt;
}

function clearVariants() {
    console.log('tick');
}