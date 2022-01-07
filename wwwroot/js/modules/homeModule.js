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

    let presenter = document.getElementById("presenter");
    let animeContainers = document.querySelectorAll(".p-layer .animate-container");
    let secondaryAnimeContainers = document.querySelectorAll(".p-layer .animate-s-container");
    let letterSpans = document.querySelectorAll(".p-layer .animate.letters");
    let effectElements = document.querySelectorAll(".p-layer .eff-el");
    let logo = document.querySelector(".p-layer .logo");
    let noSignal = document.querySelector(".p-layer #final-media");

    let StartAnimationObject = {
        first: {
            targets: presenter,
            opacity: [0, 1],
            scale: [1.05, 1],
            borderRadius: "50%",
            easing: "easeOutQuint",
            duration: animationOptions.duration,
            delay: 200,
            offt: "-=300"
        },
        second: {
            targets: presenter,
            rotate: 360,
            borderRadius: "0",
            easing: 'easeOutQuint',
            duration: animationOptions.duration,
            offt: "-=300"
        },
        third: {
            targets: presenter,
            width: animationOptions.newWidth + "rem",
            height: animationOptions.newHeight + "rem",
            easing: "easeOutQuint",
            duration: animationOptions.duration,
            offt: "-=300"
        },
        fourth: {
            targets: presenter,
            background: "#240090",
            easing: "easeOutQuint",
            duration: animationOptions.duration,
            offt: "-=300"
        },
        fifth: {
            targets: presenter,
            boxShadow: "-15px -15px 0px 0px rgb(53, 0, 211)",
            easing: "linear",
            duration: animationOptions.duration,
            offt: "-=300"
        },
        sixth: {
            targets: letterSpans,
            opacity: [0, 1],
            translateY: [-200, 0],
            easing: "easeOutQuint",
            duration: animationOptions.duration,
            delay: anime.stagger(animationOptions.stagger),
            offt: "-=300"
        },
        seventh: {
            targets: animeContainers,
            width: "3rem",
            height: "3rem",
            borderRadius: "50%",
            background: "#ffffff",
            easing: "easeOutElastic(1, .5)",
            duration: animationOptions.duration,
            delay: anime.stagger(animationOptions.stagger),
            offt: "-=300"
        },
        eighth: {
            targets: animeContainers,
            translateX: function (el, index, arr) {
                let val;
                switch (index) {
                    case 0:
                        val = (animationOptions.newWidth / 2) - 1.5 - (2.5);
                        break;
                    case 2:
                        val = - (animationOptions.newWidth / 2) + 1.5 + (2.5);
                        break;
                    default:
                }

                return val + "rem";
            },
            translateY: function (el, index, arr) {
                let val;
                switch (index) {
                    case 0:
                        val = (animationOptions.newHeight / 2) - 1.5 - (2.5);
                        break;
                    case 2:
                        val = - (animationOptions.newHeight / 2) + 1.5 + (2.5);
                        break;
                    default:
                }

                return val + "rem";
            },
            easing: "easeOutElastic(1, .5)",
            duration: animationOptions.duration,
            delay: anime.stagger(animationOptions.stagger),
            offt: "-=300"
        },
        ninth: {
            targets: secondaryAnimeContainers,
            translateX: function (el, index, arr) {
                let val;
                switch (index) {
                    case 0:
                        val = (animationOptions.newWidth / 2) - 1.5 - (2.5);
                        break;
                    case 1:
                        val = - (animationOptions.newWidth / 2) + 1.5 + (2.5);
                        break;
                    default:
                }

                return val + "rem";
            },
            translateY: function (el, index, arr) {
                let val;
                switch (index) {
                    case 0:
                        val = (animationOptions.newHeight / 2) - 1.5 - (2.5);
                        break;
                    case 1:
                        val = - (animationOptions.newHeight / 2) + 1.5 + (2.5);
                        break;
                    default:
                }

                return val + "rem";
            },
            easing: "easeOutElastic(1, .5)",
            duration: animationOptions.duration - 1000,
            delay: anime.stagger(animationOptions.stagger),
            offt: "-=300"
        },
        tenth: {
            targets: secondaryAnimeContainers,
            opacity: [0, 1],
            easing: "easeOutElastic(1, .5)",
            duration: 300,
            delay: anime.stagger(animationOptions.stagger),
            offt: "-=300"
        },
        eleventh: {
            targets: animeContainers,
            opacity: [1, 0],
            easing: "easeOutElastic(1, .5)",
            duration: 300,
            offt: "-=300"
        },
        twelfth: {
            targets: secondaryAnimeContainers,
            translateX: 0,
            translateY: 0,
            easing: "easeOutElastic(1, .5)",
            duration: animationOptions.duration,
            offt: "-=300"
        },
        thirteenth: {
            targets: secondaryAnimeContainers,
            borderRadius: 0,
            background: "rgb(0,0,0,0)",
            width: "40rem",
            height: "15rem",
            easing: "easeOutQuint",
            duration: animationOptions.duration,
            offt: "-=300"
        },
        fourteenth: {
            targets: effectElements,
            left: function (el, index, arr) {
                return "0rem";
            },
            right: function (el, index, arr) {
                return "0rem";
            },
            easing: "easeOutQuint",
            duration: animationOptions.duration,
            offt: "-=800"
        },
        fifteenth: {
            targets: secondaryAnimeContainers,
            opacity: [1, 0],
            easing: "easeOutQuint",
            duration: animationOptions.duration,
            offt: "+=1000"
        },
        sixteenth: {
            targets: effectElements,
            translateX: function (el, index, arr) {
                if (index == 0) {
                    return "100%";
                }
                else if (index == 1) {
                    return "-100%";
                }
            },
            easing: "easeOutQuint",
            duration: animationOptions.duration,
            offt: "-=900"
        },
        nineteenth: {
            targets: logo,
            opacity: [0, 1],
            easing: "easeOutQuint",
            duration: animationOptions.duration + 1500,
            offt: "-=300"
        },
        twentieth: {
            targets: noSignal,
            opacity: [0, 1],
            easing: "easeOutQuint",
            duration: 1,
            offt: "+=300"
        },
    };

    animeInstances.Home = anime.timeline({ autoplay: false });

    for (let [key, value] of Object.entries(StartAnimationObject)) {
        animeInstances.Home.add(value, value.offt);
    }

    animeInstances.Home.play();
    BackSvgAnimation(animationOptions.duration, animationOptions.delay);

    animeInstances.Home.finished.then(function () {
        animationOptions.backLoopAniActive = false;
        noSignal.querySelector("#stop-audio").onclick = function () {
            if (animationOptions.finalAudio != null) {
                if (animationOptions.finalAudio.paused || animationOptions.finalAudio.ended) {
                    animationOptions.finalAudio.muted = false;
                    animationOptions.finalAudio.play();
                    TogglePlayIcon(false);
                } else {
                    animationOptions.finalAudio.pause();
                    TogglePlayIcon(true);
                }
            }
        };
        animationOptions.finalAudio = new Audio('/media/nosignal.mp3');
        animationOptions.finalAudio.autoplay = true;
        animationOptions.finalAudio.loop = true;
        const promise = animationOptions.finalAudio.play();
        if (promise !== undefined) {
            promise.then(() => {

            }).catch(error => {
                TogglePlayIcon(true);
            });
        }
    });
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

function TogglePlayIcon(state) {
    let btn = document.getElementById("stop-audio");
    if (state) {
        btn.querySelector("i").className = "las la-play-circle";
    }
    else {
        btn.querySelector("i").className = "las la-pause-circle";
    }
}

function BackSvgAnimation(duration, delay) {
    anime({
        targets: "#back-art",
        translateX: ["-50%", "-50%"],
        translateY: ["-50%", "-50%"],
        rotate: function () {
            return anime.random(-360, 360);
        },
        scale: function () {
            return anime.random(-0.5, 1.5);
        },
        duration: duration,
        delay: 200,
        autoplay: true,
        easing: "easeOutElastic(1, .5)",
        complete: function (anim) {
            if (anim.completed && animationOptions.backLoopAniActive) {
                BackSvgAnimation(duration, delay);
            }
        }
    });
}

//#endregion