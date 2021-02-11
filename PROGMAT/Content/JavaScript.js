function changeReservationState() {
    var decider = document.getElementById('reservationState');
    if (decider.checked)
    {
        $.ajax({
            url: '@Url.Action("AddReservation","Reservations")'
        });
    }
    else
    {
        $.ajax({
            url: '@Url.Action("DeleteReservation","Reservations")'
        });
    }
}