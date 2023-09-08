function generateSlug(title) {
    // Replace special characters and spaces with dashes
    return title
        .toLowerCase()
        .replace(/[^a-zA-Z0-9а-яА-Яա-ֆԱ-Ֆ]+/g, '-')
        .replace(/^-+|-+$/g, '')
        .replace(/-+/g, '-');
}

$(() => {
    $('#Article_Title').on('input', function () {
        let slug = generateSlug($(this).val());
        $('#Article_Slug').val(slug);
    });
})