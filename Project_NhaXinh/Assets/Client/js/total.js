
// payment
$(document).ready(function () {
    $('#cod').click(function (e) { 
      $('#transfer').removeClass(' border-dark');
      $('#cod').addClass(' border-dark');
      $('#payment_note1').hide();
      $('#payment_note2').show();;
    });
    $('#transfer').click(function (e) { 
        $('#cod').removeClass(' border-dark');
        $('#transfer').addClass(' border-dark');
        $('#payment_note2').hide();
        $('#payment_note1').show();
      });
  });
  //add cart
  $(document).ready(function(){
    $('#add_cart').click(function (e) { 
      e.preventDefault();
      $('.submenu_h2').show();
    });
  })