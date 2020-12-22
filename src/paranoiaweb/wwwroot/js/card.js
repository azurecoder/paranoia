window.cardInit = function(levelId, cardId) {
    var card = document.getElementById(cardId);


    card.addEventListener('click', function(e){
    e.stopPropagation();
    if(card.classList.contains('card--flipped')) {
        card.classList.add('card--unflip');
        setTimeout(function(){
        card.classList.remove('card--flipped', 'card--unflip');
        }, 500);
    }
    else { 
        card.classList.add("card--flipped");
    }
    });
}

/*
References in the <head> for the conic-gradient background due to lack of browser support outside of Chrome.
via: https://leaverou.github.io/conic-gradient/ 
*/