$(() => {
	$('[data-toggle="tooltip"]').tooltip();

	//Delete Modal
	$(".deleteUniversityModalBtn").click(function () {
		$("#deleteUniversityModalForm").attr("action", `${$("#deleteUniversityModalForm").data("action")}/${$(this).data("id")}`)
	})
})