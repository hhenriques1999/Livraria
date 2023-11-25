document.getElementById('imageUpload').addEventListener('change', function (event) {
    var file = event.target.files[0];
    var reader = new FileReader();
    reader.onload = function (readerEvent) {
        var image = new Image();
        image.onload = function (imageEvent) {
            // Resize the image
            var canvas = document.createElement('canvas');
            var maxSize = 220; // Max height or width
            var width = image.width;
            var height = image.height;
            if (width > height) {
                if (width > maxSize) {
                    height *= maxSize / width;
                    width = maxSize;
                }
            } else {
                if (height > maxSize) {
                    width *= maxSize / height;
                    height = maxSize;
                }
            }
            canvas.width = width;
            canvas.height = height;
            canvas.getContext('2d').drawImage(image, 0, 0, width, height);
            document.getElementById('base64Image').value = canvas.toDataURL('image/jpeg');
            document.getElementById('resizedImage').src = canvas.toDataURL('image/jpeg');
        }
        image.src = readerEvent.target.result;
    }
    reader.readAsDataURL(file);
});