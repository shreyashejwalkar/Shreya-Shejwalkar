 $(function () {
            $("#checkAll").click(function () {
                $("input[name='employeeIdsToDelete']").attr("checked", this.checked);

                $("input[name='employeeIdsToDelete']").click(function () {
                    if ($("input[name='employeeIdsToDelete']").length == $("input[name='employeeIdsToDelete']:checked").length) {
                        $("#checkAll").attr("checked", "checked");
                    }
                    else {
                        $("#checkAll").removeAttr("checked");
                    }
                });

            });
            $("#btnSubmit").click(function () {
                var count = $("input[name='employeeIdsToDelete']:checked").length;
                if (count == 0) {
                    alert("No rows selected to delete");
                    return false;
                }
                else {
                    return confirm(count + " row(s) will be deleted");
                }
            });
        });