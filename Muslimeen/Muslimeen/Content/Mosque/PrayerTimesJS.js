function verifyPrayerTimes() {
    FajrA = document.getElementById("txtFajrA").value;
    FajrJ = document.getElementById("txtFajrJ").value;
    DhuhrA = document.getElementById("txtDhuhrA").value;
    DhuhrJ = document.getElementById("txtDhuhrJ").value;
    AsrA = document.getElementById("txtAsrA").value;
    AsrJ = document.getElementById("txtAsrJ").value;
    MagribA = document.getElementById("txtMagribA").value;
    MagribJ = document.getElementById("txtMagribJ").value;
    EishaA = document.getElementById("txtEishaA").value;
    EishaJ = document.getElementById("txtEishaJ").value;
    button = document.getElementById("lblMessage").innerText;

    if (FajrA < FajrJ) {
        if (FajrJ < DhuhrA) {
            if (DhuhrA < DhuhrJ) {
                if (DhuhrJ < AsrA) {
                    if (AsrA < AsrJ) {
                        if (AsrJ < MagribA) {
                            if (MagribA < MagribJ) {
                                if (MagribJ < EishaA) {
                                    if (EishaA < EishaJ) {
                                        if (button === "Add Prayer Times For ") {
                                            document.getElementById("BtnAdd").disabled = false;
                                        }
                                        else if (button === "Update Prayer Times For ") {
                                            document.getElementById("BtnUpdate").disabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                   
            }
        }
    }



}