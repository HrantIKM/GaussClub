$(() => {
	$('[data-toggle="tooltip"]').tooltip();

	//Delete Modal
	$(".deleteArticleModalBtn").click(function () {
		$("#deleteArticleModalForm").attr("action", `${$("#deleteArticleModalForm").data("action")}/${$(this).data("id")}`)
	})
})