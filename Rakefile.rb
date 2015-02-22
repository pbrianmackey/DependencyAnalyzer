require 'rake'

desc "Usage: rake 'query[projectName,assemblyName]'.  Tells you if a project is referenced by another project somewhere in the chain (direct and transitive)"
task :query, [:arg1, :arg2] do |t, args|

	#puts "Project Name : ";
	#projectName = STDIN.gets.chomp;

	#puts "Assembly Name : (without .dll)";
	#assemblyName = STDIN.gets.chomp;
	#puts "args: #{args}"
	#puts "#{args.arg1} #{args.arg2}"

	#sh("RunSample.bat #{args.arg1} #{args.arg2}")

	exec "RunSample.bat #{args.arg1} #{args.arg2}"
end