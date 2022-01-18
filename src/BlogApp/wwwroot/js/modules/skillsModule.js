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

    anime({
        targets: `#skills-block .skill-article-header-item`,
        translateY: [-15, 0],
        opacity: [0, 1],
        easing: "easeOutQuint",
        duration: 1000,
        delay: anime.stagger(100, { start: 100 }),
        autoPlay: true,
        loop: false
    });
}

export function Stagger(blockId) {
    anime({
        targets: `#${blockId} .skill-block`,
        translateX: function () {
            return [anime.random(-500, 500), 0];
        },
        translateY: function () {
            return [anime.random(-500, 500), 0];
        },
        opacity: [0, 1],
        easing: "easeOutQuint",
        duration: 1000,
        delay: anime.stagger(100),
        autoPlay: true,
        loop: false
    });
}

export function Dispose() {

}

//#endregion