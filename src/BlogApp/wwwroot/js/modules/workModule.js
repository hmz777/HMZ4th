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
        targets: '.content-article',
        opacity: [0, 1],
        translateY: [50, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        delay: anime.stagger(100, { start: 100 }),
        autoPlay: true,
        loop: false
    });
}

export function Dispose() {

}

//#endregion