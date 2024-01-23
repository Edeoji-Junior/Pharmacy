$(function () {
	debugger;
	var taskId = $(this).find('.davesTask').val()
	var newTaskStatusId = ""
	$(".kanban-wrap").sortable({
		connectWith: ".kanban-wrap",
		cursor: "pointer",
		helper: "clone",
		items: "#sortableRow",
		stop: function (event, ui) {
			debugger;
			var $item = ui.item;
			newTaskStatusId = $item.parent().attr("id");
			// Here's where am ajax call will go
			$.ajax({
				type: 'POST',
				url: '/Admin/ChangeTaskStatus', // we are calling json method
				data: {
					newTaskStatusId: newTaskStatusId,
					taskId: taskId
				},
				success: function (result) {
				},
			});
		}
	}).disableSelection();