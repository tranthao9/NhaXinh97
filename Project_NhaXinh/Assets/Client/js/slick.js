// slide thưuong hiệu
$(document).ready(function(){
    $('.image_slider').slick({
      slidesToShow: 6,
      slidesToScroll: 1,
      Infinite:false,
      arrows:false,
      autoplay: true,
      autoplaySpeed: 2000,
    });
  });
  $(document).ready(function(){
	$('.slider-for').slick({
		slidesToShow: 1,
		slidesToScroll: 1,
		arrows: true,
		fade: true,
		asNavFor: '.slider-nav'
	  });
	 
  });
  $(document).ready(function(){
	$('.slider-nav').slick({
		slidesToShow: 2,
		slidesToScroll: 1,
		asNavFor: '.slider-for',
		focusOnSelect: true,
	  });
  })
$(document).ready(function(){
    $('.menu_children').click(function(e){
        $('.submenu_h').css({
            'display': 'block',
        });
    });
	$('.btn-close').click(function(e){
		$('.submenu_h').css({
		  'display': 'none',
	  });
	  })
})
$(document).ready(function(){
    $('.menu_children2').click(function(e){
        $('.submenu_h2').css({
            'display': 'block',
        });
    });
	$('.btn-close').click(function(e){
		$('.submenu_h2').css({
		  'display': 'none',
	  });
	  })
})
$(function() {
	var Accordion = function(el, multiple) {
		this.el = el || {};
		this.multiple = multiple || false;

		// Variables privadas
		var links = this.el.find('.link');
		// Evento
		links.on('click', {el: this.el, multiple: this.multiple}, this.dropdown)
	}

	Accordion.prototype.dropdown = function(e) {
		var $el = e.data.el;
			$this = $(this),
			$next = $this.next();

		$next.slideToggle();
		$this.parent().toggleClass('open');

		if (!e.data.multiple) {
			$el.find('.submenu').not($next).slideUp().parent().removeClass('open');
		};
    if (!e.data.multiple) {
			$el.find('.submenu').not($next).slideUp().parent().removeClass('open');
		};
	}	

	var accordion = new Accordion($('#accordion'), false);
});
$(function() {
	var Accordion = function(el, multiple) {
		this.el = el || {};
		this.multiple = multiple || false;

		// Variables privadas
		var links = this.el.find('.link');
		// Evento
		links.on('click', {el: this.el, multiple: this.multiple}, this.dropdown)
	}

	Accordion.prototype.dropdown = function(e) {
		var $el = e.data.el;
			$this = $(this),
			$next = $this.next();

		$next.slideToggle();
		$this.parent().toggleClass('open');

		if (!e.data.multiple) {
			$el.find('.submenu').not($next).slideUp().parent().removeClass('open');
		};
    if (!e.data.multiple) {
			$el.find('.submenu').not($next).slideUp().parent().removeClass('open');
		};
	}	

	var accordion = new Accordion($('#accordion2'), false);
});


