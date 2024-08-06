function changeCreateBtn() {
    let createBtn = document.getElementById('create-btn');
    if (createBtn.classList.contains('btn-primary')) {
        createBtn.classList.remove('btn-primary');
    }
    createBtn.classList.add('btn-warning');
}

function findImages() {
    let cards = document.getElementsByClassName('card');
    for (let card of cards) {
        let cardText = card.getElementsByClassName('card-text')[0];
        let imgage = cardText.getElementsByTagName('img')[0];
        //not prod solution
        let paragraphWithImg = cardText.getElementsByTagName('p')[0];
        let titlePicture = card.getElementsByClassName('card-img-custom')[0];
        titlePicture.src = imgage.src;
        titlePicture.alt = imgage.alt;
        cardText.removeChild(paragraphWithImg);
    }
}

