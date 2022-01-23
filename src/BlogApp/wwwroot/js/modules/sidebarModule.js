var sidebar = document.querySelector(".sidebar");
var sidebarBtn = document.querySelector(".sidebar-toggle");

export function InitHandler(componentRef) {
    if (window.matchMedia("(max-width: 991px)").matches) {
        document.onclick = function (e) {
            if (e.target.className.indexOf("side-link") != -1) {
                componentRef.invokeMethodAsync("HideSidebar");
            }
        }
    }
}