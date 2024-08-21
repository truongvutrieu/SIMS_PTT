var lastResults = [];
var selectedIds = new Set();
function initializeSelect2(courseId) {
    let lastTerm = '';
    
    var $select = $('#studentSelect');
    if ($select.length) {
        // Destroy previous instance if it exists
        if ($select.data('select2')) {
            $select.select2('destroy');
        }

        $select.select2({
            ajax: {
                url: `/api/Students/search?courseId=${courseId}`,
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    lastTerm = params.term || '';
                    return {
                        term: lastTerm
                    };
                },
                processResults: function (data) {
                    lastResults = data.filter(item => !selectedIds.has(item.id));
                    return {
                        results: lastResults
                    };
                }
            },
            placeholder: 'Search for a student',
            closeOnSelect: false,
            minimumInputLength:1
        }).on('select2:select', function (e) {
            var selectedId = e.params.data.id;
            selectedIds.add(selectedId);

            lastResults = lastResults.filter(item => item.id !== selectedId);

            // Use a timeout to allow UI updates
            setTimeout(() => {
                $select.select2('open');
                $('.select2-search__field').val(lastTerm).trigger('input');
                $select.data('select2').dataAdapter.addOptions(lastResults);
            }, 0);
        });
    } else {
        console.error('Element #studentSelect not found.');
    }
}

function getSelectedValues(elementId) {
    return $(`#${elementId}`).val();
}

 function clearSelect2(elementId) {
     $('#' + elementId).val([]).trigger('change');
     lastResults = [];
     selectedIds = new Set();
    }