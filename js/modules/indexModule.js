//#region Vars

var animeInstances = {};
var animationOptions = {
    duration: 1000,
    stagger: 200,
    center: 50,
    newWidth: 60,
    newHeight: 40,
    backLoopAniActive: true,
    finalAudio: null
};


//#endregion

//#region API

export function InitAnimation() {

    let fSpans = document.querySelectorAll("#presenter-1 .f-span");
    let sSpans = document.querySelectorAll("#presenter-1 .s-span");
    let svg = document.querySelectorAll("#presenter-1 svg");

    let StartAnimationObject = {
        f: {
            targets: fSpans,
            translateY: [-70, 0],
            opacity: [0, 1],
            easing: "easeOutElastic(1, .5)",
            duration: 1200,
            delay: anime.stagger(200, { start: 100 }),
            offt: "-=1"
        },
        s: {
            targets: sSpans,
            opacity: [0, 1],
            translateY: function (el, index, arr) {
                if (index == 0) {
                    return [70, 0];
                }
                else {
                    return [-70, 0];
                }
            },
            easing: "easeOutElastic(1, .5)",
            duration: 1000,
            offt: "-=500"
        },
        t: {
            targets: "#presenter-1 svg path",
            strokeDashoffset: [anime.setDashoffset, 0],
            easing: 'easeInOutSine',
            duration: 2500,
            offt: "-=500"
        }
    };

    animeInstances.Home = anime.timeline({ autoplay: false });

    for (let [key, value] of Object.entries(StartAnimationObject)) {
        animeInstances.Home.add(value, value.offt);
    }

    animeInstances.Home.play();
}

export function Dispose() {
    for (let [key, value] of Object.entries(animeInstances)) {
        value.pause();
        value.reset();
        value = null;
    }
}

//#endregion

//#region Functions


//#endregion