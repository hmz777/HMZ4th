//#region Vars

//#endregion

//#region API

export function InitAnimation() {
    anime({
        targets: '.article-header h1, .header-link',
        opacity: [0, 1],
        translateY: [500, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        autoPlay: true,
        delay: anime.stagger(100),
        loop: false
    });

    anime({
        targets: '#about-block h2',
        opacity: [0, 1],
        translateY: [-20, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        delay: anime.stagger(100, { start: 100 }),
        autoPlay: true,
        loop: false
    });

    anime({
        targets: '#about-block li',
        opacity: [0, 1],
        translateX: [-20, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        delay: anime.stagger(100, { start: 100 }),
        autoPlay: true,
        loop: false
    });

    anime({
        targets: '#about-block .app-meta',
        opacity: [0, 1],
        translateY: [20, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        autoPlay: true,
        loop: false
    });
}

export function Dispose() {

}

//#endregion