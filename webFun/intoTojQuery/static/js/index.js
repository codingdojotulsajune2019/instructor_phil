$(document).ready(function(){
    $('#show button').click(function(){
        // show changes the display properity
        $('#show p').show();
    })
    $('#hide button').click(function(){
        $('#hide p').hide();
    })
    $('#toggle button').click(function(){
        $('#toggle p').toggle();
    })
})