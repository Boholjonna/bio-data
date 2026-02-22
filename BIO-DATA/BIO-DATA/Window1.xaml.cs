/*
 * Created by SharpDevelop.
 * User: ASUS
 * Date: 2/16/2026
 * Time: 10:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace BIO_DATA
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		#region Country model
		public class CountryInfo
		{
			public string Name { get; set; }
			public string IsoCode { get; set; }
			public string DialCode { get; set; }
			
			// Computed display: "[PH] Philippines (+63)"
			public string DisplayName {
				get {
					return string.Format("{0} {1} ({2})", GetFlagEmoji(IsoCode), Name, DialCode);
				}
			}
			
			public string Flag {
				get { return GetFlagEmoji(IsoCode); }
			}
			
			private static string GetFlagEmoji(string isoCode)
			{
				// Note: Computing real emoji flags requires surrogate pair math on code points > 0xFFFF,
				// which can cause overflow issues in older environments. For reliability we fall back
				// to a simple text-based flag marker like "[PH]".
				if (string.IsNullOrEmpty(isoCode) || isoCode.Length != 2)
					return string.Empty;
				
				return "[" + isoCode.ToUpperInvariant() + "]";
			}
		}
		#endregion
		
		private readonly List<CountryInfo> _countries = new List<CountryInfo>();
		
		public Window1()
		{
			InitializeComponent();
			InitializeCountries();
			InitializeDefaults();
		}
		
		private void InitializeCountries()
		{
			// Core set of countries with correct international dialing codes.
			// You can extend this list further if needed.
			_countries.AddRange(new[] {
				new CountryInfo { Name = "Afghanistan", IsoCode = "AF", DialCode = "+93" },
				new CountryInfo { Name = "Albania", IsoCode = "AL", DialCode = "+355" },
				new CountryInfo { Name = "Algeria", IsoCode = "DZ", DialCode = "+213" },
				new CountryInfo { Name = "Argentina", IsoCode = "AR", DialCode = "+54" },
				new CountryInfo { Name = "Australia", IsoCode = "AU", DialCode = "+61" },
				new CountryInfo { Name = "Austria", IsoCode = "AT", DialCode = "+43" },
				new CountryInfo { Name = "Bangladesh", IsoCode = "BD", DialCode = "+880" },
				new CountryInfo { Name = "Belgium", IsoCode = "BE", DialCode = "+32" },
				new CountryInfo { Name = "Brazil", IsoCode = "BR", DialCode = "+55" },
				new CountryInfo { Name = "Brunei Darussalam", IsoCode = "BN", DialCode = "+673" },
				new CountryInfo { Name = "Cambodia", IsoCode = "KH", DialCode = "+855" },
				new CountryInfo { Name = "Canada", IsoCode = "CA", DialCode = "+1" },
				new CountryInfo { Name = "China", IsoCode = "CN", DialCode = "+86" },
				new CountryInfo { Name = "Denmark", IsoCode = "DK", DialCode = "+45" },
				new CountryInfo { Name = "Egypt", IsoCode = "EG", DialCode = "+20" },
				new CountryInfo { Name = "France", IsoCode = "FR", DialCode = "+33" },
				new CountryInfo { Name = "Germany", IsoCode = "DE", DialCode = "+49" },
				new CountryInfo { Name = "Greece", IsoCode = "GR", DialCode = "+30" },
				new CountryInfo { Name = "Hong Kong", IsoCode = "HK", DialCode = "+852" },
				new CountryInfo { Name = "India", IsoCode = "IN", DialCode = "+91" },
				new CountryInfo { Name = "Indonesia", IsoCode = "ID", DialCode = "+62" },
				new CountryInfo { Name = "Ireland", IsoCode = "IE", DialCode = "+353" },
				new CountryInfo { Name = "Israel", IsoCode = "IL", DialCode = "+972" },
				new CountryInfo { Name = "Italy", IsoCode = "IT", DialCode = "+39" },
				new CountryInfo { Name = "Japan", IsoCode = "JP", DialCode = "+81" },
				new CountryInfo { Name = "Kenya", IsoCode = "KE", DialCode = "+254" },
				new CountryInfo { Name = "Korea, Republic of", IsoCode = "KR", DialCode = "+82" },
				new CountryInfo { Name = "Kuwait", IsoCode = "KW", DialCode = "+965" },
				new CountryInfo { Name = "Lao People's Democratic Republic", IsoCode = "LA", DialCode = "+856" },
				new CountryInfo { Name = "Malaysia", IsoCode = "MY", DialCode = "+60" },
				new CountryInfo { Name = "Mexico", IsoCode = "MX", DialCode = "+52" },
				new CountryInfo { Name = "Netherlands", IsoCode = "NL", DialCode = "+31" },
				new CountryInfo { Name = "New Zealand", IsoCode = "NZ", DialCode = "+64" },
				new CountryInfo { Name = "Nigeria", IsoCode = "NG", DialCode = "+234" },
				new CountryInfo { Name = "Norway", IsoCode = "NO", DialCode = "+47" },
				new CountryInfo { Name = "Pakistan", IsoCode = "PK", DialCode = "+92" },
				new CountryInfo { Name = "Philippines", IsoCode = "PH", DialCode = "+63" },
				new CountryInfo { Name = "Poland", IsoCode = "PL", DialCode = "+48" },
				new CountryInfo { Name = "Portugal", IsoCode = "PT", DialCode = "+351" },
				new CountryInfo { Name = "Qatar", IsoCode = "QA", DialCode = "+974" },
				new CountryInfo { Name = "Russian Federation", IsoCode = "RU", DialCode = "+7" },
				new CountryInfo { Name = "Saudi Arabia", IsoCode = "SA", DialCode = "+966" },
				new CountryInfo { Name = "Singapore", IsoCode = "SG", DialCode = "+65" },
				new CountryInfo { Name = "South Africa", IsoCode = "ZA", DialCode = "+27" },
				new CountryInfo { Name = "Spain", IsoCode = "ES", DialCode = "+34" },
				new CountryInfo { Name = "Sri Lanka", IsoCode = "LK", DialCode = "+94" },
				new CountryInfo { Name = "Sweden", IsoCode = "SE", DialCode = "+46" },
				new CountryInfo { Name = "Switzerland", IsoCode = "CH", DialCode = "+41" },
				new CountryInfo { Name = "Taiwan", IsoCode = "TW", DialCode = "+886" },
				new CountryInfo { Name = "Thailand", IsoCode = "TH", DialCode = "+66" },
				new CountryInfo { Name = "Turkey", IsoCode = "TR", DialCode = "+90" },
				new CountryInfo { Name = "United Arab Emirates", IsoCode = "AE", DialCode = "+971" },
				new CountryInfo { Name = "United Kingdom", IsoCode = "GB", DialCode = "+44" },
				new CountryInfo { Name = "United States", IsoCode = "US", DialCode = "+1" },
				new CountryInfo { Name = "Viet Nam", IsoCode = "VN", DialCode = "+84" }
			});
			
			NationalityCombo.ItemsSource = _countries;
			
			// Default to Philippines if available (matches example +63)
			CountryInfo defaultCountry = _countries.Find(c => c.IsoCode == "PH");
			if (defaultCountry == null && _countries.Count > 0)
				defaultCountry = _countries[0];
			
			if (defaultCountry != null)
			{
				NationalityCombo.SelectedItem = defaultCountry;
				UpdateCountryCodeDisplay(defaultCountry);
			}
		}
		
		private void InitializeDefaults()
		{
			CivilStatusCombo.SelectedIndex = 0;
		}
		
		private void UpdateCountryCodeDisplay(CountryInfo country)
		{
			if (country == null)
				return;
			
			CountryFlagTextBlock.Text = country.Flag;
			CountryCodeTextBlock.Text = country.DialCode;
		}
		
		private void BirthdatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			if (BirthdatePicker.SelectedDate.HasValue)
			{
				DateTime today = DateTime.Today;
				DateTime birthDate = BirthdatePicker.SelectedDate.Value.Date;
				
				if (birthDate > today)
				{
					AgeTextBox.Text = string.Empty;
					return;
				}
				
				int age = today.Year - birthDate.Year;
				if (birthDate > today.AddYears(-age))
					age--;
				
				AgeTextBox.Text = age.ToString();
			}
			else
			{
				AgeTextBox.Text = string.Empty;
			}
		}
		
		private void GenderCheckBox_Checked(object sender, RoutedEventArgs e)
		{
			// Ensure only one gender checkbox is selected at a time
			if (sender == MaleCheckBox && MaleCheckBox.IsChecked == true)
			{
				FemaleCheckBox.IsChecked = false;
			}
			else if (sender == FemaleCheckBox && FemaleCheckBox.IsChecked == true)
			{
				MaleCheckBox.IsChecked = false;
			}
		}
		
		private void NationalityCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CountryInfo selected = NationalityCombo.SelectedItem as CountryInfo;
			if (selected != null)
			{
				UpdateCountryCodeDisplay(selected);
			}
		}
		
		private void ContactNumberTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			// Allow only digits in the local part of the phone number
			foreach (char c in e.Text)
			{
				if (!char.IsDigit(c))
				{
					e.Handled = true;
					break;
				}
			}
		}
		
		private void SubmitButton_Click(object sender, RoutedEventArgs e)
		{
			// Example basic validation & summary.
			// You can extend this as needed.
			
			if (string.IsNullOrWhiteSpace(NameTextBox.Text))
			{
				MessageBox.Show("Please enter your full name.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
				NameTextBox.Focus();
				return;
			}
			
			if (!BirthdatePicker.SelectedDate.HasValue)
			{
				MessageBox.Show("Please select your birthdate.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
				BirthdatePicker.Focus();
				return;
			}
			
			if (MaleCheckBox.IsChecked != true && FemaleCheckBox.IsChecked != true)
			{
				MessageBox.Show("Please select your gender.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
				MaleCheckBox.Focus();
				return;
			}
			
			if (NationalityCombo.SelectedItem == null)
			{
				MessageBox.Show("Please select your nationality.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
				NationalityCombo.Focus();
				return;
			}
			
			if (string.IsNullOrWhiteSpace(ContactNumberTextBox.Text))
			{
				MessageBox.Show("Please enter your contact number.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
				ContactNumberTextBox.Focus();
				return;
			}
			
			CountryInfo country = NationalityCombo.SelectedItem as CountryInfo;
			string gender = MaleCheckBox.IsChecked == true ? "Male" : "Female";
			string fullPhone = string.Format("{0} {1}", CountryCodeTextBlock.Text, ContactNumberTextBox.Text);
			
			ComboBoxItem civilStatusItem = CivilStatusCombo.SelectedItem as ComboBoxItem;
			string civilStatus = civilStatusItem != null ? Convert.ToString(civilStatusItem.Content) : string.Empty;
			
			string summary = string.Format(
				"Name: {0}\nAddress: {1}\nBirthdate: {2:d}\nAge: {3}\nGender: {4}\nCivil Status: {5}\nNationality: {6}\nContact: {7}",
				NameTextBox.Text,
				AddressTextBox.Text,
				BirthdatePicker.SelectedDate.Value,
				AgeTextBox.Text,
				gender,
				civilStatus,
				country != null ? country.Name : string.Empty,
				fullPhone
			);
			
			MessageBox.Show(summary, "Submitted Bio Data", MessageBoxButton.OK, MessageBoxImage.Information);
		}
		
		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			// Clear basic text fields
			NameTextBox.Text = string.Empty;
			AddressTextBox.Text = string.Empty;
			AgeTextBox.Text = string.Empty;
			ContactNumberTextBox.Text = string.Empty;
			
			// Reset date and age
			BirthdatePicker.SelectedDate = null;
			
			// Reset gender
			MaleCheckBox.IsChecked = false;
			FemaleCheckBox.IsChecked = false;
			
			// Reset civil status to first item (e.g., Single) if available
			if (CivilStatusCombo.Items.Count > 0)
				CivilStatusCombo.SelectedIndex = 0;
			
			// Reset nationality back to default Philippines (PH) if present,
			// otherwise first in the list
			CountryInfo defaultCountry = _countries.Find(c => c.IsoCode == "PH");
			if (defaultCountry == null && _countries.Count > 0)
				defaultCountry = _countries[0];
			
			if (defaultCountry != null)
			{
				NationalityCombo.SelectedItem = defaultCountry;
				UpdateCountryCodeDisplay(defaultCountry);
			}
		}
		
		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show(
				"Are you sure you want to exit?",
				"Confirm Exit",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question
			);
			
			if (result == MessageBoxResult.Yes)
			{
				Application.Current.Shutdown();
			}
		}
	}
}