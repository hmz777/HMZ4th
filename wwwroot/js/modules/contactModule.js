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
        targets: '.form-el',
        opacity: [0, 1],
        translateY: [50, 0],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        autoPlay: true,
        loop: false,
        delay: anime.stagger(100, { start: 100 })
    });
}

export function GetRecaptchaResponse() {
    try {
        return grecaptcha.getResponse();
    } catch (e) {
        return null;
    }
}

export function Dispose() {

}

//#endregion