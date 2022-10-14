/**
 * @license Copyright (c) 2003-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	config.extraPlugis = 'syntaxhighlight';
	config.syntaxhighlight_lang = 'csharp';
	config.syntaxhighlight_hideControls = true;
	config.language = 'vi';
	config.filebrowserBrowseUrl = '/Assets/Admin/Plugin/ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '/Assets/Admin/Plugin/ckfinder/ckfinder.html?Type=Images';
	config.filebrowserFlashBrowseUrl = '/Assets/Admin/Plugin/ckfinder/ckfinder.html?Type=Flash';
	config.filebrowserUploadUrl = '/Assets/Admin/Plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '/Assets/Admin/images';
	config.filebrowserFlashUploadUrl = '/Assets/Admin/Plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
	CKFinder.setupCKEditor(null, '/Assets/Admin/Plugin/ckfinder');

};
