using static System.Net.WebRequestMethods;

namespace Laba2CloudTechnologies;

public partial class Form1 : Form
{
    private AzureStorageManager _azureStorageManager = null!;
    private TextBox _lastNameTextBox = null!;
    private TextBox _firstNameTextBox = null!;
    private TextBox _middleNameTextBox = null!;
    private TextBox _addressTextBox = null!;
    private TextBox _photoUrlTextBox = null!;
    private TextBox _phoneNumbersTextBox = null!;

    private Label _lastNameLabel = null!;
    private Label _firstNameLabel = null!;
    private Label _middleNameLabel = null!;
    private Label _addressLabel = null!;
    private Label _photoUrlLabel = null!;
    private Label _phoneNumbersLabel = null!;

    private TextBox _updateLastNameTextBox = null!;
    private TextBox _updateFirstNameTextBox = null!;
    private TextBox _updatemiddleNameTextBox = null!;
    private TextBox _updateAddressTextBox = null!;
    private TextBox _updatePhotoUrlTextBox = null!;
    private TextBox _updatePhoneNumbersTextBox = null!;

    Label _updateLastNameLabel = null!,
        _updateFirstNameLabel = null!,
        _updatemiddleNameLabel = null!,
        _updateAddressLabel = null!,
        _updatePhotoUrlLabel = null!,
        _updatePhoneNumbersLabel = null!;

    private Label _deleteLastNameLabel = null!, _deleteFirstNameLabel = null!;
    private TextBox _deleteLastNameTextBox = null!, _deleteFirstNameTextBox = null!;

    private Button _addContactButton = null!;
    private Button _updateContactButton = null!;
    private Button _deleteContactButton = null!;
    private Button _showContactsButton = null!;
    private DataGridView _contactsDataGridView = null!;

    public Form1()
    {
        InitializeComponent();
        InitializeAzureStorage();
        InitializeUi();
    }

    private async void InitializeAzureStorage()
    {
        const string storageConnectionString =
            "DefaultEndpointsProtocol=https;AccountName=lab3serhi;AccountKey=8ctmbHxruimUR/VciY/3aR8DxXv/U4nC/Z10LFvuVlzIYqeHRIAQ74uDTII3sJej5QWL2xJLn59b+AStgiE7wA==;EndpointSuffix=core.windows.net";
        _azureStorageManager = new AzureStorageManager(storageConnectionString);

        await _azureStorageManager.InitializeAsync();
    }
    private void InitializeUi()
    {
        InitializeAddContactUi();
        InitializeUpdateContactUi();
        InitializeDeleteContactUi();


        _showContactsButton = new Button { Text = "Show Contacts", Top = 220, Left = 10, Height = 30 };
        _showContactsButton.Click += ShowContactsButton_Click;

        _contactsDataGridView = new DataGridView
        {
            Top = 220,
            Left = 100,
            Width = 740,
            Height = 200,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };

        Controls.Add(_lastNameLabel);
        Controls.Add(_firstNameLabel);
        Controls.Add(_middleNameLabel);
        Controls.Add(_addressLabel);
        Controls.Add(_photoUrlLabel);
        Controls.Add(_phoneNumbersLabel);

        Controls.Add(_lastNameTextBox);
        Controls.Add(_firstNameTextBox);
        Controls.Add(_middleNameTextBox);
        Controls.Add(_addressTextBox);
        Controls.Add(_photoUrlTextBox);
        Controls.Add(_phoneNumbersTextBox);
        Controls.Add(_addContactButton);
        Controls.Add(_updateContactButton);
        Controls.Add(_deleteContactButton);
        Controls.Add(_showContactsButton);
        Controls.Add(_contactsDataGridView);
    }

    private void InitializeAddContactUi()
    {
        int labelWidth = 100;
        int textBoxWidth = 100;
        int spacing = 10;

        int currentLeft = spacing;

        // Initialize Labels
        _lastNameLabel = new Label { Text = "Last Name:", Top = 10, Left = currentLeft, Width = labelWidth };
        currentLeft += labelWidth + spacing;

        _firstNameLabel = new Label { Text = "First Name:", Top = 10, Left = currentLeft, Width = labelWidth };
        currentLeft += labelWidth + spacing;

        _middleNameLabel = new Label { Text = "middleName:", Top = 10, Left = currentLeft, Width = labelWidth };
        currentLeft += labelWidth + spacing;

        _addressLabel = new Label { Text = "Address:", Top = 10, Left = currentLeft, Width = labelWidth };
        currentLeft += labelWidth + spacing;

        _photoUrlLabel = new Label { Text = "Photo URL:", Top = 10, Left = currentLeft, Width = labelWidth };
        currentLeft += labelWidth + spacing;

        _phoneNumbersLabel = new Label
        { Text = "Phone Numbers:", Top = 10, Left = currentLeft, Width = 20 + labelWidth };

        // Reset currentLeft for TextBoxes and Buttons
        currentLeft = spacing;

        // Initialize TextBoxes
        _lastNameTextBox = new TextBox { Top = 30, Left = currentLeft, Width = textBoxWidth };
        currentLeft += labelWidth + spacing;

        _firstNameTextBox = new TextBox { Top = 30, Left = currentLeft, Width = textBoxWidth };
        currentLeft += labelWidth + spacing;

        _middleNameTextBox = new TextBox { Top = 30, Left = currentLeft, Width = textBoxWidth };
        currentLeft += labelWidth + spacing;

        _addressTextBox = new TextBox { Top = 30, Left = currentLeft, Width = textBoxWidth };
        currentLeft += labelWidth + spacing;

        _photoUrlTextBox = new TextBox { Top = 30, Left = currentLeft, Width = textBoxWidth };
        currentLeft += labelWidth + spacing;

        _phoneNumbersTextBox = new TextBox { Top = 30, Left = currentLeft, Width = 20 + textBoxWidth };
        currentLeft += labelWidth + spacing;

        _addContactButton = new Button
        { Text = "Add Contact", Top = 30, Left = 20 + currentLeft, Width = textBoxWidth, Height = 35 };
        _addContactButton.Click += AddContactButton_Click;
    }

    private void InitializeUpdateContactUi()
    {
        int labelWidth = 100;
        int textBoxWidth = 100;
        int buttonWidth = 100;
        int spacing = 10;
        int currentLeft = spacing;
        int topPositionForUpdate = 90; // Positioning the update fields below the add fields

        // Initialize Labels for Updating Contacts
        _updateLastNameLabel = new Label
        { Text = "Update Last:", Top = topPositionForUpdate, Left = currentLeft, Width = labelWidth };
        currentLeft += labelWidth + spacing;

        _updateFirstNameLabel = new Label
        { Text = "Update First:", Top = topPositionForUpdate, Left = currentLeft, Width = labelWidth };
        currentLeft += labelWidth + spacing;

        _updatemiddleNameLabel = new Label
        { Text = "Update middleName:", Top = topPositionForUpdate, Left = currentLeft, Width = labelWidth };
        currentLeft += labelWidth + spacing;

        _updateAddressLabel = new Label
        { Text = "Update Address:", Top = topPositionForUpdate, Left = currentLeft, Width = labelWidth };
        currentLeft += labelWidth + spacing;

        _updatePhotoUrlLabel = new Label
        { Text = "Update Photo URL:", Top = topPositionForUpdate, Left = currentLeft, Width = labelWidth };
        currentLeft += labelWidth + spacing;

        _updatePhoneNumbersLabel = new Label
        { Text = "Update Phones:", Top = topPositionForUpdate, Left = currentLeft, Width = labelWidth };
        currentLeft += labelWidth + spacing;

        // Reset currentLeft for TextBoxes and Buttons for Updating Contacts
        currentLeft = spacing;

        // Initialize TextBoxes for Updating Contacts
        _updateLastNameTextBox = new TextBox
        { Top = topPositionForUpdate + 20, Left = currentLeft, Width = textBoxWidth };
        currentLeft += labelWidth + spacing;

        _updateFirstNameTextBox = new TextBox
        { Top = topPositionForUpdate + 20, Left = currentLeft, Width = textBoxWidth };
        currentLeft += labelWidth + spacing;

        _updatemiddleNameTextBox = new TextBox
        { Top = topPositionForUpdate + 20, Left = currentLeft, Width = textBoxWidth };
        currentLeft += labelWidth + spacing;

        _updateAddressTextBox = new TextBox
        { Top = topPositionForUpdate + 20, Left = currentLeft, Width = textBoxWidth };
        currentLeft += labelWidth + spacing;

        _updatePhotoUrlTextBox = new TextBox
        { Top = topPositionForUpdate + 20, Left = currentLeft, Width = textBoxWidth };
        currentLeft += labelWidth + spacing;

        _updatePhoneNumbersTextBox = new TextBox
        { Top = topPositionForUpdate + 20, Left = currentLeft, Width = textBoxWidth };
        currentLeft += labelWidth + spacing;

        // Initialize Update Button
        _updateContactButton = new Button
        {
            Text = "Update Contact",
            Top = topPositionForUpdate + 20,
            Left = currentLeft,
            Width = buttonWidth,
            Height = 40
        };
        _updateContactButton.Click += UpdateContactButton_Click;
        // Add Controls to the Form for Updating Contacts
        Controls.Add(_updateLastNameLabel);
        Controls.Add(_updateFirstNameLabel);
        Controls.Add(_updatemiddleNameLabel);
        Controls.Add(_updateAddressLabel);
        Controls.Add(_updatePhotoUrlLabel);
        Controls.Add(_updatePhoneNumbersLabel);

        Controls.Add(_updateLastNameTextBox);
        Controls.Add(_updateFirstNameTextBox);
        Controls.Add(_updatemiddleNameTextBox);
        Controls.Add(_updateAddressTextBox);
        Controls.Add(_updatePhotoUrlTextBox);
        Controls.Add(_updatePhoneNumbersTextBox);

        Controls.Add(_updateContactButton);
    }

    private void InitializeDeleteContactUi()
    {
        int labelWidth = 100;
        int textBoxWidth = 100;
        int buttonWidth = 100;
        int spacing = 10;
        int currentLeft = spacing;
        int topPositionForDelete = 150; // Positioning the delete fields below the update fields

        // Initialize Labels for Deleting Contacts
        _deleteLastNameLabel = new Label
        { Text = "Delete Partion Key::", Top = topPositionForDelete, Left = currentLeft, Width = labelWidth + 40 };
        currentLeft += labelWidth + spacing + 40;

        _deleteFirstNameLabel = new Label
        { Text = "Delete Row Key:", Top = topPositionForDelete, Left = currentLeft, Width = labelWidth + 40 };
        currentLeft += labelWidth + spacing;

        // Reset currentLeft for TextBoxes and Buttons for Deleting Contacts
        currentLeft = spacing;

        // Initialize TextBoxes for Deleting Contacts
        _deleteLastNameTextBox = new TextBox
        { Top = topPositionForDelete + 20, Left = currentLeft, Width = textBoxWidth + 40 };
        currentLeft += labelWidth + spacing + 40;

        _deleteFirstNameTextBox = new TextBox
        { Top = topPositionForDelete + 20, Left = currentLeft, Width = textBoxWidth + 40 };
        currentLeft += labelWidth + spacing + 40;

        // Initialize Delete Button
        _deleteContactButton = new Button
        {
            Text = "Delete Contact",
            Top = topPositionForDelete + 20,
            Left = currentLeft,
            Width = buttonWidth,
            Height = 40
        };
        _deleteContactButton.Click += DeleteContactButton_Click;
        // Add Controls to the Form for Deleting Contacts
        Controls.Add(_deleteLastNameLabel);
        Controls.Add(_deleteFirstNameLabel);

        Controls.Add(_deleteLastNameTextBox);
        Controls.Add(_deleteFirstNameTextBox);

        Controls.Add(_deleteContactButton);
    }

    private async void AddContactButton_Click(object sender, EventArgs e)
    {
        string lastName = _lastNameTextBox.Text;
        string firstName = _firstNameTextBox.Text;
        string middleName = _middleNameTextBox.Text;
        string address = _addressTextBox.Text;
        string photoUrl = _photoUrlTextBox.Text;
        string phoneNumbers = _phoneNumbersTextBox.Text;

        Contact newContact = new(lastName, firstName)
        {
            middleName = middleName,
            Address = address,
            PhotoUrl = photoUrl,
            PhoneNumbers = phoneNumbers
        };

        await _azureStorageManager.InsertOrMergeEntityAsync(newContact);
    }

    private async void UpdateContactButton_Click(object sender, EventArgs e)
    {
        string lastName = _updateLastNameLabel.Text;
        string firstName = _updateFirstNameTextBox.Text;
        string middleName = _updatemiddleNameTextBox.Text;
        string address = _updateAddressTextBox.Text;
        string photoUrl = _updatePhotoUrlTextBox.Text;
        string phoneNumbers = _updatePhoneNumbersTextBox.Text;

        Contact contactToUpdate = new(lastName, firstName)
        {
            middleName = middleName,
            Address = address,
            PhotoUrl = photoUrl,
            PhoneNumbers = phoneNumbers
        };

        await _azureStorageManager.InsertOrMergeEntityAsync(contactToUpdate);
    }

    private async void DeleteContactButton_Click(object sender, EventArgs e)
    {
        string lastName = _deleteLastNameTextBox.Text;
        string firstName = _deleteFirstNameTextBox.Text;

        if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName))
        {
            MessageBox.Show("Both Last Name and First Name are required for deleting a contact.");
            return;
        }

        await _azureStorageManager.DeleteEntityAsync(new Contact(lastName, firstName) { ETag = "*" });
        MessageBox.Show("Contact deleted successfully.");
    }

    private void ShowContactsButton_Click(object? sender, EventArgs e)
    {
        List<Contact> contacts =
             _azureStorageManager.GetAllContactsAsync();
        _contactsDataGridView.DataSource = contacts;
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
}