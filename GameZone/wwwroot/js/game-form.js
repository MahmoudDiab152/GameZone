$("#Cover").change(function () {
	var preview = $(".cover-preview");
	if (preview.length > 0) {
		preview.attr('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none');
	}
});