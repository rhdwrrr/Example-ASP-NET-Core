let hoverCover = function() {
    let m = document.getElementById("coverM1");
    m.classList.remove("shadow-none");
    m.classList.add("shadow-lg");
}
let hoverOut = function() {
    let m = document.getElementById("coverM1");
    m.classList.remove("shadow-lg");
    m.classList.add("shadow-none");
}



gotoPopup = () => {
    $.ajax({
        type: "GET",
        url: url,
        success: function(response) {
            $('#form-modal .modal-body').html(response);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').show();
        }
    })
}

// let dismissModal = function() {
//     document.getElementById("form-modal").dispose();
// }



(function($) {
    function Index() {
        var $this = this;

        function initialize() {

            $("#addEditModal").on('click', function(e) {
                modelPopup(this);
            });

            function modelPopup(reff) {
                var url = $(reff).data('url');
                var ttl = $(reff).data('title');

                $.get(url).done(function(data) {
                    debugger;
                    $('#form-modal').find(".modal-body").html(data);
                    $('#form-modal').find(".modal-title").html(ttl);
                    $('.modal', data).modal("show");
                });

            }
        }

        $this.init = function() {
            initialize();
        };
    }
    $(function() {
        var self = new Index();
        self.init();
    });
}(jQuery));