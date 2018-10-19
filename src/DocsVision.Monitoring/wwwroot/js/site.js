$(document).ready(function () {
    $(body).on("mouseenter mouseleave", ".dropdown", function (e) {
        let dd = $(e.target).closest("dropdown");
        dd.addClass("show");
        setTimeout(function () {
            dd[dd.is(":hover") ? "addClass" : "removeClass"]("show");
            $("[data-toggle='dropdown']", dd).attr("aria-expanded", dd.is(":hover"));
        }, 300);
    });
});