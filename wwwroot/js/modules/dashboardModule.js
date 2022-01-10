//#region Vars

//#endregion

//#region API

export function InitAnimation() {
    anime({
        targets: '.article-header h1',
        translateY: [500, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        autoPlay: true,
        loop: false
    });

    Stagger();
}

export function Stagger() {
    anime({
        targets: "#dashboard-block .dashboard-block",
        translateY: [50, 0],
        opacity: [0, 1],
        easing: "easeOutQuint",
        duration: 1000,
        delay: anime.stagger(100, { start: 100 }),
        autoPlay: true,
        loop: false
    });
}

export function Dispose() {

}

//#endregion