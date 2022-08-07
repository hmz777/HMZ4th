//#region Vars

//#endregion

//#region API

export function InitAnimation() {
    anime({
        targets: '.article-header h1',
        opacity: [0, 1],
        translateY: [500, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        autoPlay: true,
        loop: false
    });

    anime({
        targets: '#tags-block .tag-item',
        opacity: [0, 1],
        translateX: [-10, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        autoPlay: true,
        delay: anime.stagger(100, { start: 100 }),
        loop: false
    });
}

export function ScrollElementIntoView(id) {
    document.getElementById(id).scrollIntoView();
}

export function Dispose() {

}

//#endregion