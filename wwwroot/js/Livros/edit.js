document.addEventListener("DOMContentLoaded", function () {
    var resizedImage = document.getElementById('resizedImage');
    var imageUpload = document.getElementById('imageUpload');
    var base64Image = document.getElementById('base64Image');

    var existingImage = resizedImage.getAttribute('src');

    if (existingImage) {
        resizedImage.src = existingImage;
    }

    imageUpload.addEventListener('change', function (event) {
        var file = event.target.files[0];
        if (file) {
            var reader = new FileReader();
            reader.onload = function (readerEvent) {
                var image = new Image();
                image.onload = function () {
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

                    var base64ImageValue = canvas.toDataURL('image/jpeg');
                    base64Image.value = base64ImageValue; // Update the hidden input value
                    resizedImage.src = base64ImageValue; // Update the image preview
                };
                image.src = readerEvent.target.result;
            };
            reader.readAsDataURL(file);
        }
    });
});