//#region Vars

//#endregion

//#region API

export function InitAnimation() {
    anime({
        targets: '.post-desc,.post-footer',
        opacity: [0, 1],
        translateY: [50, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        delay: anime.stagger(200, { start: 100 }),
        autoPlay: true,
        loop: false
    });
}

export function HighlightCode() {
    hljs.highlightAll(".post-body");
}

export function Dispose() {

}

//#endregion